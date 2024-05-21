import { ComponentRef, Directive, Input, OnChanges, Renderer2, SimpleChanges, ViewContainerRef } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Directive({
    selector: `button[mat-button][hhLoading],
    button[mat-raised-button][hhLoading],
    button[mat-icon-button][hhLoading],
    button[mat-fab][hhLoading],
    button[mat-mini-fab][hhLoading],
    button[mat-stroked-button][hhLoading],
    button[mat-flat-button][hhLoading]`
})
export class MatButtonLoadingDirective implements OnChanges {
    @Input() hhLoading: Nullable<boolean>;
    private spinner: ComponentRef<MatProgressSpinner> | null;

    constructor(
        private _matButton: MatButton,
        private _viewContainerRef: ViewContainerRef,
        private renderer: Renderer2
    ) { }

    ngOnChanges(changes: SimpleChanges): void {
        if (!changes['hhLoading']) {
            return;
        }

        if (changes['hhLoading'].currentValue) {
            this._matButton._elementRef.nativeElement['__prevContent'] = this._matButton._elementRef.nativeElement.innerHTML;
            this._matButton._elementRef.nativeElement.innerHTML = '';

            this._matButton.disabled = true;
            this.createSpinner();
        } else if (!changes['hhLoading'].firstChange) {
            const prevContent = this._matButton._elementRef.nativeElement['__prevContent'];
            if (prevContent) {
                this._matButton._elementRef.nativeElement.innerHTML = prevContent;
            }

            this._matButton.disabled = false;
            this.destroySpinner();
        }
    }

    private createSpinner(): void {
        if (!this.spinner) {
            this.spinner = this._viewContainerRef.createComponent(MatProgressSpinner);
            this.spinner.instance.diameter = 20;
            this.spinner.instance.mode = 'indeterminate';
            this.renderer.appendChild(this._matButton._elementRef.nativeElement, this.spinner.instance._elementRef.nativeElement);
        }
    }

    private destroySpinner(): void {
        if (this.spinner) {
            this.spinner.destroy();
            this.spinner = null;
        }
    }
}
