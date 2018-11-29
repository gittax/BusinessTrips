import { NgModule } from '@angular/core';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { ServerModule, ServerTransferStateModule } from '@angular/platform-server';

@NgModule({
  imports: [AppModule, ServerModule, ServerTransferStateModule, ModuleMapLoaderModule],
  bootstrap: [AppComponent]
})
export class AppServerModule { }
