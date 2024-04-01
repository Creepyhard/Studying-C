import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HistoricoComponent} from "./historico/historico.component";
import {JogoComponent} from "./jogo/jogo.component";

const routes: Routes = [
  {path:"historico", component:HistoricoComponent},
  {path:"jogo", component:JogoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
