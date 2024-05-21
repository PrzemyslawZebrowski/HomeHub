import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { GoogleMap, MapMarker } from '@angular/google-maps';
import { Observable } from 'rxjs';
import { AnnouncementLocalization } from 'src/app/core/models/announcements/announcement-form.model';
import { GoogleMapsService } from 'src/app/core/services/google-maps.service';

@Component({
    selector: 'hh-profile-announcement-localization-form',
    templateUrl: './profile-announcement-localization-form.component.html',
    styleUrls: ['./profile-announcement-localization-form.component.scss']
})
export class ProfileAnnouncementLocalizationFormComponent implements OnInit {
    @Input() form: FormGroup<TypedFormControls<AnnouncementLocalization>>;

    autocompleteOptions: google.maps.places.AutocompleteOptions = {
        fields: ['formatted_address', 'geometry'],
        strictBounds: false,
        types: ['route', 'locality']
    };

    mapOptions: google.maps.MapOptions = {
        zoom: 3,
        center: {
            lat: 40,
            lng: 10
        }
    };

    markerOptions: google.maps.MarkerOptions = {
        draggable: true,
        visible: false,
        position: {
            lat: 0,
            lng: 0
        }
    };

    markerPosition: google.maps.LatLng;

    mapLoaded$: Observable<boolean>;

    private _addressElementRef: ElementRef<HTMLInputElement>;

    constructor(private _googleMapsService: GoogleMapsService) { }

    ngOnInit(): void {
        this.mapLoaded$ = this._googleMapsService.mapLoaded$;

        if (this.form.value.latitude && this.form.value.longitude) {
            const position = {
                lat: this.form.value.latitude,
                lng: this.form.value.longitude
            };

            this.markerOptions.visible = true;
            this.markerOptions.position = position;
            this.mapOptions.center = position;
            this.mapOptions.zoom = 13;
        }
    }

    @ViewChild(GoogleMap) map: GoogleMap;
    @ViewChild('marker') marker: MapMarker;
    @ViewChild('address') set address(address: ElementRef) {
        if (address) {
            this._addressElementRef = address;
            this.setMapAddressAutocomplete();
        }
    }

    onMapAddressBlur(): void {
        if (!this.form.controls.address.value) {
            this.marker.marker?.setVisible(false);
            this.form.patchValue({
                latitude: null,
                longitude: null
            });
        }
    }

    onMarkerDragend(event: google.maps.MapMouseEvent): void {
        if (event.latLng) {
            this.form.patchValue({
                latitude: event.latLng.lat(),
                longitude: event.latLng.lng()
            });
        }
    }

    private setMapAddressAutocomplete(): void {
        const autocomplete = new google.maps.places.Autocomplete(this._addressElementRef.nativeElement, this.autocompleteOptions);
        google.maps.event.addListener(autocomplete, 'place_changed', () => {
            const place = autocomplete.getPlace();

            if (place.geometry && place.geometry.location) {
                this.form.patchValue({
                    address: place.formatted_address,
                    latitude: place.geometry.location.lat(),
                    longitude: place.geometry.location.lng()
                });

                this.marker.marker?.setVisible(true);
                this.marker.marker?.setPosition(place.geometry.location);
                this.map.googleMap?.setCenter(place.geometry.location);
                this.map.googleMap?.setZoom(13);
            }
        });
    }


}
