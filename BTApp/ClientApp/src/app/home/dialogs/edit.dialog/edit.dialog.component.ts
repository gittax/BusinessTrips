import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpService } from '../../../services/http.service'
import { HomeComponent } from '../../home.component';


@Component({
  selector: 'app-edit.dialog',
  templateUrl: './edit.dialog.component.html',
  styleUrls: ['./edit.dialog.component.css']
})
export class EditDialogComponent {

  newRequest: Request;

  constructor(public dialogRef: MatDialogRef<EditDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any, public httpService: HttpService) { }

  formControl = new FormControl('', [
      Validators.required
      // Validators.email,
    ]);

    getErrorMessage() {
      return this.formControl.hasError('required') ? 'Required field' :
        this.formControl.hasError('email') ? 'Not a valid email' :
          '';
    }

  submit() {
      // emppty stuff
    }

  onNoClick(): void {
      this.dialogRef.close();
    }

  stopEdit(): void {
    this.httpService.putRequest(this.data.id, this.data.request)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    }
  }
