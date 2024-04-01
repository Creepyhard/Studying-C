import {Component, OnInit} from '@angular/core';
import {Historico} from "../models/Historico";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {HistoricoComponent} from "../historico/historico.component";

@Component({
  selector: 'app-jogo',
  templateUrl: './jogo.component.html',
  styleUrl: './jogo.component.css'
})
export class JogoComponent implements OnInit {
  private baseUrl = "https://localhost:7089/historico"

  historicos: Historico[] = [];
  historico: Historico = new Historico();
  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

  iniciaJogoRequest(historico: Historico){
    this.http.post<any>(`https://localhost:7089/historico/criajogo`, historico.dificuldade).subscribe(
      (result) => {
        this.historico = result;
      });
  }

  retornaUltimoHistorico(historico: Historico) {
    this.http.post<any>(`https://localhost:7089/historico/retornaUltimo`, historico).subscribe(
      (result) => {
        this.historico = result;
      })
  }
}
