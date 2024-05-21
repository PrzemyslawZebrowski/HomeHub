import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { Page } from '../models/pagination-criteria.model';
import { UserDetailsForm } from '../models/users/user-form.model';
import { UserInfo } from '../models/users/user-info.model';
import { User, UserDetails, UserPaginationCriteria } from '../models/users/user.model';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private _http: HttpClient) { }

    registerUser(): Observable<void> {
        return this._http.post<void>(`${environment.apiUrl}/users/register`, {});
    }

    getCurrentUserInfo(): Observable<UserInfo | null> {
        return this._http.get<UserInfo | null>(`${environment.apiUrl}/users/info`);
    }

    getUsers(criteria: UserPaginationCriteria): Observable<Page<User>> {
        return this._http.get<Page<User>>(`${environment.apiUrl}/users`, {
            params: criteria
        });
    }

    getUserDetails(userId: string): Observable<UserDetails> {
        return this._http.get<UserDetails>(`${environment.apiUrl}/users/${userId}/details`);
    }

    getCurrentUserDetails(): Observable<UserDetails> {
        return this._http.get<UserDetails>(`${environment.apiUrl}/users/details`);
    }

    updateUserRole(userId: string, roleId: number): Observable<void> {
        return this._http.put<void>(`${environment.apiUrl}/users/${userId}/role`, { roleId });
    }

    updateCurrentUserDetails(userDetails: UserDetailsForm): Observable<void> {
        return this._http.put<void>(`${environment.apiUrl}/users/details`, userDetails);
    }
}
