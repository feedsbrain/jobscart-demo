import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routing';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { ListingComponent } from './components/listing/listing.component';
import { LoginComponent } from './components/login/login.component';
import { OrderComponent } from './components/order/order.component';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent, HeaderComponent, FooterComponent, ConfirmComponent, ListingComponent, LoginComponent, OrderComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    BrowserModule,
    MaterialModule,
    FlexLayoutModule,
    MDBBootstrapModule.forRoot()
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
