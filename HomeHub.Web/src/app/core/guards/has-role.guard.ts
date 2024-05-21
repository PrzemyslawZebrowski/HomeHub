import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, UrlTree } from '@angular/router';
import { filter, map, Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

import { UserRoleEnum } from '../enums/users/user-role.enum';

export const HasRoleGuard: CanActivateFn = (
    route: ActivatedRouteSnapshot
): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree => {
    const requiredRoles = route.data['requiredRoles'] as UserRoleEnum[];
    const router = inject(Router);
    const authService = inject(AuthService);

    return authService.userInfo$.pipe(
        filter(user => !!user),
        map(user => {
            const role = user?.roleId;
            if (role && requiredRoles.includes(role)) {
                return true;
            } else {
                router.navigate(['/access-denied']);
                return false;
            }
        })
    );

};
