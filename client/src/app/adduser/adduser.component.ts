import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css'],
})
export class AdduserComponent implements OnInit {
  model: any = {};
  userForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    userRole: new FormControl(''),
    userActive: new FormControl(false),
  });

  constructor(private readonly userService: UsersService) {}

  ngOnInit(): void {}

  onAdd(newUser: any) {
    this.userService.addUser(newUser).subscribe({
      next: (response) => console.log('User Added'),
      error: (error) => console.log(error),
    });
  }
}
