import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Funcionario } from 'src/app/models/funcionario';

@Component({
  selector: 'app-listar-funcionarios',
  templateUrl: './listar-funcionarios.component.html',
  styleUrls: ['./listar-funcionarios.component.css']
})
export class ListarFuncionariosComponent implements OnInit {

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
          console.table(funcionarios);
        }
      });
  }

}
