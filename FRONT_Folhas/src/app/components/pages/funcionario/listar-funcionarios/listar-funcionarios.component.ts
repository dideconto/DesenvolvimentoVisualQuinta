import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Funcionario } from 'src/app/models/funcionario';

@Component({
  selector: 'app-listar-funcionarios',
  templateUrl: './listar-funcionarios.component.html',
  styleUrls: ['./listar-funcionarios.component.css']
})
export class ListarFuncionariosComponent implements OnInit {

  funcionarios!: Funcionario[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    //Configurando a requisição para a API
    this.http.
      get<Funcionario[]>(
        "https://localhost:5001/api/funcionario/listar"
      )
      // Executar a requisição
      .subscribe({
        next: (funcionarios) => {
          //Executamos o que for necessário quando a requisição
          //for bem-sucedida
          this.funcionarios = funcionarios;
        }
      });
  }

  remover(id: number): void {
    this.http.
      delete<Funcionario>
      (`https://localhost:5001/api/funcionario/deletar/${id}`)
      .subscribe({
        next: (funcionario) => {
          this.ngOnInit();
        },
      });
  }

}
