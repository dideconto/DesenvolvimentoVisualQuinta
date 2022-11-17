import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Folha } from "src/app/models/folha";
import { Funcionario } from "src/app/models/funcionario";

@Component({
  selector: "app-cadastrar-folha",
  templateUrl: "./cadastrar-folha.component.html",
  styleUrls: ["./cadastrar-folha.component.css"],
})
export class CadastrarFolhaComponent implements OnInit {
  valorHora!: number;
  quantidadeHoras!: number;
  data!: string;
  funcionarios!: Funcionario[];
  funcionarioId!: number;

  constructor(private http: HttpClient, private router: Router, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.http.get<Funcionario[]>("https://localhost:5001/api/funcionario/listar").subscribe({
      next: (funcionarios) => {
        this.funcionarios = funcionarios;
      },
    });
  }

  cadastrar(): void {
    console.log(this.funcionarioId);
    let dataConvertida = new Date(this.data);

    let folha: Folha = {
      valorHora: this.valorHora,
      quantidadeHoras: this.quantidadeHoras,
      ano: dataConvertida.getFullYear(),
      mes: dataConvertida.getMonth() + 1,
      funcionarioId: this.funcionarioId,
    };

    this.http.post<Folha>("https://localhost:5001/api/folha/cadastrar", folha).subscribe({
      next: (folha) => {
        this._snackBar.open("Folha cadastrada!", "Ok!", {
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        this.router.navigate(["pages/folha/listar"]);
      },
    });
  }
}
