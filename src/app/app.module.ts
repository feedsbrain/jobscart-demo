import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routing';
import { FlexLayoutModule } from "@angular/flex-layout";
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
import { ProgressSpinnerModule } from 'primeng/primeng';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent, HeaderComponent, FooterComponent, ConfirmComponent, ListingComponent, LoginComponent, OrderComponent
  ],
  imports: [
    HttpModule,
    RouterModule.forRoot(AppRoutes),
    BrowserModule,
    MaterialModule,
    FlexLayoutModule,
    NgbModule.forRoot(),
    ProgressSpinnerModule
  ],
  providers: [AuthGuard, ProductService],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
