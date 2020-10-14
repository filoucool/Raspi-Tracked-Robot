<?php
$servername = "127.0.0.1";
$username = "root";
$password = "";
$dbname = "tso";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "";

$sql = "SELECT IR1, IR2, IR3, IR4, IR5, IRSDIST, LONGG, LAT, ALT, QUALITY, SATT FROM Sensors";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "START". "IR1" . $row["IR1"]. "IR2" . $row["IR2"]. "IR3" . $row["IR3"]. "IR4" . $row["IR4"]. "IR5" . $row["IR5"]. "IRSDIST" . $row["IRSDIST"]. "LONGG" . $row["LONGG"]. "LAT" . $row["LAT"]. "ALT" . $row["ALT"]. "SATT" . $row["SATT"]."END" . "<br>";
  }
} else {
  echo "ERROR, NO RESULTS";
}
$conn->close();

?>