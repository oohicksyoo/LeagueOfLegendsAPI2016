<?php
	$functionName = $_POST["functionName"];
	
	switch ($functionName) 
	{
		case 'summonerInformation':
			$region = $_POST["region"];
			$summonerName = $_POST["summonerName"];
			SummonerInformation($region,$summonerName);
			break;
		
		default:
			break;
	}
	
	//FUNCTIONS
	function SummonerInformation($region,$summonerName)
	{
		//$results = file_get_contents("https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/Its%20Freelo%20Time?api_key=0b9c6c6b-6384-43f8-a653-542fdd27710c");
		$results = file_get_contents("https://" . $region . ".api.pvp.net/api/lol/" . $region . "/v1.4/summoner/by-name/Its%20Freelo%20Time?api_key=0b9c6c6b-6384-43f8-a653-542fdd27710c");
		echo $results;
	}
?>

