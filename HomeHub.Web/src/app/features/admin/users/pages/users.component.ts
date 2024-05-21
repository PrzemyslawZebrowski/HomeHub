import { Component, OnInit } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject, filter, Observable, switchMap } from 'rxjs';
import { Page } from 'src/app/core/models/pagination-criteria.model';
import { User, UserPaginationCriteria } from 'src/app/core/models/users/user.model';
import { DialogService } from 'src/app/core/services/dialog.service';
import { UserService } from 'src/app/core/services/user.service';

import { UserRoleDialogComponent, UserRoleDialogData } from '../dialogs/user-role-dialog/user-role-dialog.component';


@Component({
    selector: 'hh-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
    displayedColumns = ["email", "roleName", "actions"];
    users$: Observable<Page<User>>;
    criteria$ = new BehaviorSubject<UserPaginationCriteria>({
        pageSize: 10,
        pageNumber: 1
    });

    constructor(private _userService: UserService, private _dialogService: DialogService, private _translateService: TranslateService) { }

    ngOnInit(): void {
        this.users$ = this.criteria$.pipe(
            switchMap(criteria => this._userService.getUsers(criteria))
        );
    }

    onSetRoleClick(user: User): void {
        this._dialogService.openDialog<UserRoleDialogComponent, UserRoleDialogData>(UserRoleDialogComponent, this._translateService.instant("Admin.Users.Menu.SetRole"), {
            userId: user.id,
            roleId: user.roleId
        }).afterClosed().pipe(
            filter(v => !!v)
        ).subscribe(() => {
            this.refreshUsers();
        });
    }

    private refreshUsers(): void {
        this.criteria$.next(this.criteria$.value);
    }

    onPageChanged(paginationCriteria: UserPaginationCriteria): void {
        this.criteria$.next(paginationCriteria);
    }

    onSortChange(sortState: Sort): void {
        this.criteria$.next({ ...this.criteria$.value, orderBy: `${sortState.active} ${sortState.direction}` });
    }
}
