import { Routes } from '@angular/router'
import { TestComponent } from './test/test.component'
import { HomeComponent } from './home/home.component'

export const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: 'home', component: HomeComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home' }

]
