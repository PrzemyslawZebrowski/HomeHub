import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UserDetails } from 'src/app/core/models/users/user.model';
import { UserService } from 'src/app/core/services/user.service';

@Component({
    selector: 'hh-user-bar',
    templateUrl: './user-bar.component.html',
    styleUrls: ['./user-bar.component.scss']
})
export class UserBarComponent implements OnInit {
    userId: string;
    userDetails$: Observable<UserDetails>;

    constructor(private _userService: UserService, private _route: ActivatedRoute) {
        this.userId = this._route.snapshot.paramMap.get('id') as string;
    }

    ngOnInit(): void {
        this.userDetails$ = this._userService.getUserDetails(this.userId);
    }
}
