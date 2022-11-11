export interface Folha {
    id?: number;
    funcionarioId: number;
    valorHora: number;
    quantidadeHoras: number;
    mes: number;
    ano: number;
    criadoEm?: string;
}