// Declaração das variáveis
var notaProva1;
var notaProva2;
var media;
var status;

// Pedir a nota da Prova 1
notaProva1 = parseFloat(prompt("Digite a nota da Prova 1:"));

// Pedir a nota da Prova 2
notaProva2 = parseFloat(prompt("Digite a nota da Prova 2:"));

// Calcular a média
media = (notaProva1 + notaProva2) / 2;

// Exibir a média Final
console.log("A média final é: " + media);

// Verificar se o aluno foi aprovado ou reprovado
if (media >= 6) {
    status = "Aprovado";
} else {
    status = "Reprovado";
}

// Exibir o status do aluno
console.log("O aluno está " + status + ".");
