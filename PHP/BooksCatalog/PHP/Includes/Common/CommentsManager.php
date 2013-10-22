<?php
class CommentsManager {
	private $conn;
	
	public function CommentsManager($host, $username, $password, $dbname) {
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
	
	public function GetComments($bookId) {
		if($this->IsValidId($bookId)) {
			return $this->GetByBookIdFromTable("comments", $bookId);
		}
	}
	
	public function AddComment($bookId, $content, $username) {
		if( $this->IsValidId($bookId) &&
			isset($content) &&
			isset($username)) {
			
			$userId = $this->GetUserIdByUsername($username);
			$dateNow = date("Y-m-d H:i:s");
			$query = "INSERT INTO comments VALUES (NULL, '{$content}', '{$dateNow}', '{$userId}', '{$bookId}')";
			$this->conn->query($query);
			
			return true;
		}
		
		return false;
	}
	
	private function GetByBookIdFromTable($tableName, $bookId) {
		$all = Array();
		
		if ($items = $this->conn->query("SELECT content, date, userId FROM {$tableName} WHERE bookId = {$bookId} ORDER BY date")) {
			while($currItem = $items->fetch_object()) {
				$username = $this->conn->query("SELECT username FROM users WHERE id = '{$currItem->userId}'");
				$username = $username->fetch_object();
				
				array_push($all, array( "username" => $username->username, 
										"content" => $currItem->content,
										"date" => $currItem->date) );
			}

			$items->close();		
		}
		
		return $all;
	}
	
	private function GetUserIdByUsername($username) {
		$users = $this->conn->query("SELECT id FROM users WHERE username = '{$username}'");
		return $users->fetch_object()->id;
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
