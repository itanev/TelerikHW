<?php
	class UserManager {
		private $conn;
		
		public function UserManager($host, $username, $password, $dbname) {
			if( !$this->IsValidConnectionProperty($host) || 
				!$this->IsValidConnectionProperty($username) ||
				!$this->IsValidConnectionProperty($password) || 
				!$this->IsValidConnectionProperty($dbname) ) {
				
				echo "Invalid connection properies!";
				return;
			}
			
			$this->conn = mysqli_connect($host, $username, $password, $dbname);

			if (mysqli_connect_errno($this->conn)){
				echo "Failed to connect to MySQL: " . mysqli_connect_error();
			}			
		}
		
		public function Register($username, $password) {
			if($this->IsValidProp($username) && $this->IsValidProp($password)) {
				if($this->Exist($username)) {
					echo "User with that username already exist!";
					return false;
				}
				
				$password = sha1($password);
				$query = "INSERT INTO `books_catalog`.`users` (`id`, `username`, `password`) VALUES (NULL, '{$username}', '{$password}')";
				$this->conn->query($query);
				
				return true;
			}
			
			return false;
		}
		
		public function Login($username, $password) {
			if($this->IsValidProp($username) && $this->IsValidProp($password)) { 
				$password = sha1($password);
				$user = $this->conn->query("SELECT * FROM users WHERE username = '{$username}' AND password = '{$password}'");
				if ($user->fetch_object()) {
					return true;
				}
			}
			
			return false;
		}
		
		private function Exist($username) {
			$users = $this->conn->query("SELECT * FROM users WHERE username = '{$username}'");
			if ($users->fetch_object()) {
				return true;
			}
			
			return false;
		}
		
		private function IsValidProp($prop) {
			if(!isset($prop)) {
				return false;
			}
			
			return true;
		}
		
		private function IsValidId($id) {
			if(!isset($id)) {
				return false;
			}
		
			if(!is_numeric($id)) {
				return false;
			}
			
			if($id < 0) {
				return false;
			}
			
			return true;
		}

		private function IsValidConnectionProperty($prop) {
			if(!isset($prop)) {
				return false;
			}
			
			return true;
		}
		
		function __destruct() {
			mysqli_close($this->conn);
		}
	}