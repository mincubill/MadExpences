import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TransactionsComponent } from './transactions/transactions.component';
import { NewTransactionComponent } from './new-transaction/new-transaction.component';


const routes: Routes = [
  {path: 'transactions', component: TransactionsComponent },
  {path: 'newTransaction', component: NewTransactionComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
