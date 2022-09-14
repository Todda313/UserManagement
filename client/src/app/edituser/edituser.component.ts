import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css'],
})
export class EdituserComponent implements OnInit {
  userId: string;
  user: any = {};
  roles: string[] = ['Goalkeeper', 'Defender', 'Midfielder', 'Forward'];

  userForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    userRole: new FormControl(''),
    userActive: new FormControl(''),
  });

  constructor(
    private readonly userService: UsersService,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.userId = params.get('id');

      if (this.userId) {
        this.userService.getUser(this.userId).subscribe({
          next: (response) => (
            (this.user = response),
            this.userForm.controls['firstName'].setValue(response.firstName),
            this.userForm.controls['lastName'].setValue(response.lastName),
            this.userForm.controls['userRole'].setValue(response.userRole),
            this.userForm.controls['userActive'].setValue(response.userActive)
          ),
          error: (error) => console.log(error),
        });
      }
    });
  }

  onUpdate(updatedUser: any) {
    this.userService.updateUser(this.userId, updatedUser).subscribe({
      next: (response) => console.log('UserUpdated'),
      error: (error) => console.log(error),
    });
  }

  onDelete() {
    this.userService.deleteUser(this.userId).subscribe({
      next: (response) => console.log('User Deleted'),
      error: (error) => console.log(error),
    });
  }
}
