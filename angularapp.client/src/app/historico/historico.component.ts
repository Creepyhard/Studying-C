import {Component, OnInit} from '@angular/core';
import {Historico} from "../models/Historico";
import {HttpClient} from "@angular/common/http";
import {Subject} from "rxjs";

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrl: './historico.component.css'
})
export class HistoricoComponent implements OnInit {

  historicos: Historico[] = [];
  dtoptions: DataTables.Settings = {};
  dtTrigger:Subject<any>=new Subject<any>();

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.dtoptions = {
      pagingType: 'full_numbers',
      searching:true,
      //  paging:false
      lengthChange:false,
      language:{
        searchPlaceholder:'Text Customer'
      }
    };
    this.getHistorico();
  }

  getHistorico() {
    this.http.get<Historico[]>('https://localhost:7089/historico').subscribe(
      (result) => {
        this.historicos = result;
        this.dtTrigger.next(null);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
