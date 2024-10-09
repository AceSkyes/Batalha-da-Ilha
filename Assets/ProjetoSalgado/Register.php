<?php

require 'Conexão.php';

$usuario = $_POST["login"];
$passe = $_POST["senha"];
$defaultVitDer = 0;


$sql = "SELECT apelido FROM usuarios WHERE apelido = '" . $usuario . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) 
{

    echo "Nome de usuário já existe!";

} 
else {
  
    echo "Usuário sendo criado...";
    $sql2 = "INSERT INTO usuarios (apelido, senha, vitorias, derrotas) VALUES ('" . $usuario . "', '".$passe."', '".$defaultVitDer."', '".$defaultVitDer."')";
    if ($conn->query($sql2) === TRUE)
    {
        echo "Usuário criado com sucesso";
    }
    else
    {
        echo "Erro na criação da conta.";
        echo $conn->error;
    }

}
$conn->close();

?>