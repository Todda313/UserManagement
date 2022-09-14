import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private baseURL = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get<any>(this.baseURL + 'users');
  }

  getUser(userId: string) {
    return this.http.get<any>(this.baseURL + 'users/' + userId);
  }

  updateUser(userId: string, updateRequest: any) {
    const updateUser: any = {
      firstName: updateRequest.firstName,
      lastName: updateRequest.lastName,
      userRole: updateRequest.userRole,
      userActive: updateRequest.userActive,
    };

    return this.http.put<any>(this.baseURL + 'users/' + userId, updateUser);
  }

  deleteUser(userId: string) {
    return this.http.delete<any>(this.baseURL + 'users/' + userId);
  }

  addUser(addRequest: any) {
    let isActive: Boolean = false;
    if (addRequest == 'true') {
      isActive = true;
    }

    const newUser: any = {
      firstName: addRequest.firstName,
      lastName: addRequest.lastName,
      userRole: addRequest.userRole,
      userActive: addRequest.userActive,
    };

    return this.http.post<any>(this.baseURL + 'users/adduser', newUser);
  }
}
