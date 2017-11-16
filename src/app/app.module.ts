import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routing';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { ListingComponent } from './components/listing/listing.component';
import { LoginComponent } from './components/login/login.component';
import { OrderComponent } from './components/order/order.component';
import { AuthGuard } from './guards/auth.guard';
import { ProductService } from './services/product.service';
import { ProgressSpinnerModule, DialogModule, SpinnerModule, MessagesModule, MessageModule, GrowlModule } from 'primeng/primeng';
import { HttpModule } from '@angular/http';
import { AppConfig } from '../app.config';
import { LoginService } from './services/login.service';
import { FormsModule } from '@angular/forms';
import { OrderService } from './services/order.service';

@NgModule({
  declarations: [
    AppComponent, HeaderComponent, FooterComponent, ConfirmComponent, ListingComponent, LoginComponent, OrderComponent
  ],
  imports: [
    HttpModule,
    RouterModule.forRoot(AppRoutes),
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    NgbModule.forRoot(),
    ProgressSpinnerModule,
    DialogModule,
    SpinnerModule,
    MessagesModule,
    MessageModule,
    GrowlModule,
    FormsModule
  ],
  providers: [AppConfig, AuthGuard, LoginService, ProductService, OrderService],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
