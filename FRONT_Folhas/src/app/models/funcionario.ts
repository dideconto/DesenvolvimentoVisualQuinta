export interface Funcionario {
    funcionarioId?: number;
    nome: string;
    cpf: string;
    email: string;
    salario: number;
    nascimento: string;
    criadoEm?: string;
}