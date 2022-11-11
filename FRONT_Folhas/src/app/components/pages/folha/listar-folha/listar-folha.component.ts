import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Folha } from "src/app/models/folha";

@Component({
  selector: "app-listar-folha",
  templateUrl: "./listar-folha.component.html",
  styleUrls: ["./listar-folha.component.css"],
})
export class ListarFolhaComponent implements OnInit {
  folhas!: Folha[];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    //Configuração da requisição
    this.http
      .get<Folha[]>("https://localhost:5001/api/folha/listar")
      // Execução da requisição
      .subscribe({
        next: (folhas) => {
          // console.table(funcionarios);
          this.folhas = folhas;
        },
      });
  }
}
