/* eslint-disable  @typescript-eslint/no-explicit-any */

type TypedFormControls<T extends Record<string, any>> = {
    [K in keyof T]: T[K] extends Array<any>
        ? import('@angular/forms').FormArray<import('@angular/forms').FormGroup<TypedFormControls<T[K][0]>>>
        : T[K] extends Record<string, any>
            ? import('@angular/forms').FormGroup<TypedFormControls<T[K]>>
            : import('@angular/forms').FormControl<T[K]>;
};
