<?php

require 'Conexão.php';

$usuario = $_POST["login"];
$passe = $_POST["senha"];

$sql = "SELECT senha FROM usuarios WHERE apelido = '" . $usuario . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["senha"] == $passe)
    {

        echo "Usuário Logado.";

    }
    else
    {

        echo "Senha incorreta.";

    }
  }
} else {
  echo "Usuário não encontrado.";
}
$conn->close();

?>