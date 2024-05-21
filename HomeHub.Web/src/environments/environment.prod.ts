export const environment = {
    production: true,
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
