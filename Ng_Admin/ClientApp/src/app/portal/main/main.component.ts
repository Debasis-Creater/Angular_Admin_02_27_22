import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/NgCore/Services/AppServices/auth.service';
import { AuthModel } from 'src/app/NgCore/Models/authModel.Model';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
auth:AuthModel=new AuthModel();
  constructor(private authService:AuthService) { }

  ngOnInit() {
  }

}
