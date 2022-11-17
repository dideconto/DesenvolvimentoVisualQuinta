import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Funcionario } from "src/app/models/funcionario";

@Component({
  selector: "app-cadastrar-funcionario",
  templateUrl: "./cadastrar-funcionario.component.html",
  styleUrls: ["./cadastrar-funcionario.component.css"],
})
export class CadastrarFuncionarioComponent implements OnInit {
  nome!: string;
  cpf!: string;
  email!: string;
  nascimento!: string;
  mensagem!: string;
  id!: string;

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: (params) => {
        let { id } = params;
        if (id !== undefined) {
          this.http.get<Funcionario>(`https://localhost:5001/api/funcionario/buscar/${id}`).subscribe({
            next: (funcionario) => {
              this.id = id;
              this.nome = funcionario.nome;
              this.cpf = funcionario.cpf;
            },
          });
        }
      },
    });
  }

  alterar(): void {
    let funcionario: Funcionario = {
      funcionarioId: Number.parseInt(this.id),
      nome: this.nome,
      cpf: this.cpf,
      salario: 950,
      email: this.email,
      nascimento: this.nascimento,
    };

    this.http.patch<Funcionario>("https://localhost:5001/api/funcionario/alterar", funcionario).subscribe({
      next: (funcionario) => {
        this._snackBar.open("Funcionário alterado!", "Ok!", {
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        this.router.navigate(["pages/funcionario/listar"]);
      },
    });
  }

  cadastrar(): void {
    let funcionario: Funcionario = {
      nome: this.nome,
      cpf: this.cpf,
      salario: 950,
      email: this.email,
      nascimento: this.nascimento,
    };

    //Configurando a requisição para a API
    this.http
      .post<Funcionario>("https://localhost:5001/api/funcionario/cadastrar", funcionario)
      // Executar a requisição
      .subscribe({
        next: (funcionario) => {
          //Executamos o que for necessário quando a requisição
          //for bem-sucedida
          this._snackBar.open("Funcionário cadastrado!", "Ok!", {
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/funcionario/listar"]);
        },
        error: (error) => {
          //Executamos o que for necessário quando a requisição
          //for mal-sucedida
          if (error.status === 400) {
            this.mensagem = "Algum erro de validação aconteceu!";
          } else if (error.status === 0) {
            this.mensagem = "A sua API não está rodando!";
          }
        },
      });
  }
}
