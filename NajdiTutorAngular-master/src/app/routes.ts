import { Routes } from '@angular/router'
import { TestComponent } from './test/test.component'
import { HomeComponent } from './home/home.component'
import { CategoriesMainComponent } from './categories-main/categories-main.component'
import { SingleCategoryComponent } from './single-category/single-category.component'

export const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: 'home', component: HomeComponent },
  { path: 'categories', component: CategoriesMainComponent },
  { path: 'categories/foreignlanguages', component: SingleCategoryComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home' }

]
