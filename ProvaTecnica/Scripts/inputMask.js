$(function () {
    $("input[data_tipo=''cpf'']").mask("000.000.000-00");
    $("input[data_tipo=''data'']").mask("00/00/0000");
    $("input[data_tipo=''moeda'']").mask("000.000.000,00", { reverse: true });
});