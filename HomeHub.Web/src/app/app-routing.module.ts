import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccessDeniedComponent } from './core/components/access-denied/access-denied.component';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';

const routes: Routes = [
    {
        path: 'not-found',
        component: PageNotFoundComponent
    },
    {
        path: 'access-denied',
        component: AccessDeniedComponent
    },
    {
        path: '**',
        redirectTo: 'not-found',
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
