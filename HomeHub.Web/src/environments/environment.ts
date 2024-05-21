// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: false,
    apiUrl: 'https://localhost:7001',
    clientUrl: 'http://localhost:4200',
    googleMapsApiKey: 'test',
    maxUploadedFileSizeInBytes: 10485760,
    auth: {
        scopes: [
            "https://test.onmicrosoft.com/test/Api.Read"
        ],
        clientId: "test",
        tenatId: "test",
        authority: "https://test.b2clogin.com/test.onmicrosoft.com/B2C_1_SignUpSingIn",
        domain: "test.b2clogin.com"
    }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
