import {
    Component,
    ComponentRef,
    Inject,
    Injector,
    OnDestroy,
    OnInit,
    Type,
    ViewChild,
    ViewContainerRef
} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

export type DialogSettings<T> = {
    component: Type<T>;
    title: string;
};

@Component({
    selector: 'hh-dialog',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.scss']
})
export class DialogComponent<T, D> implements OnInit, OnDestroy {
    @ViewChild('target', { read: ViewContainerRef, static: true }) viewContainerRef: ViewContainerRef;

    componentRef: ComponentRef<T>;
    dialogSettings: DialogSettings<T>;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: D,
        private _injector: Injector
    ) { }

    ngOnInit(): void {
        if (this.dialogSettings.component) {
            this.componentRef = this.viewContainerRef.createComponent(
                this.dialogSettings.component,
                {
                    injector: Injector.create({
                        providers: [
                            {
                                provide: MAT_DIALOG_DATA, useValue: this.data
                            }
                        ],
                        parent: this._injector
                    })
                }
            );
        }
    }

    ngOnDestroy(): void {
        if (this.componentRef) {
            this.componentRef.destroy();
        }
    }
}
