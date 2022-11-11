import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { CadastrarFuncionarioComponent } from "./components/pages/funcionario/cadastrar-funcionario/cadastrar-funcionario.component";
import { ListarFuncionariosComponent } from "./components/pages/funcionario/listar-funcionarios/listar-funcionarios.component";
import { CadastrarFolhaComponent } from './components/pages/folha/cadastrar-folha/cadastrar-folha.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastrarFuncionarioComponent,
    ListarFuncionariosComponent,
    CadastrarFolhaComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule,
    HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
