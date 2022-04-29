# SerraMadeMe

<table>
    <tr>
        <th>Endpoint</th>
        <th>Intention</th>
        <th>Request Body</th>
        <th>Response Body</th>
    </tr>
    <tr>
        <td>GET api/Characters </td>
        <td>Return all Characters in DB </td>
        <td>N/A</td>
        <td>
            <pre>
                <code>
{
  "statusCode": 200,
  "statusDescription": "OK",
  "charactersList": [
      {
          "characterId": 1,
          "characterName": "SKY",
          "creationDate": "2022-04-29T00:00:00",
          "weapon1Id": 1,
          "weapon2Id": 1,
          "weapon3Id": 1
      },
      {
          "characterId": 3,
          "characterName": "JAY4123",
          "creationDate": "2022-04-29T00:00:00",
          "weapon1Id": 1,
          "weapon2Id": 1,
          "weapon3Id": 1
      }
  ],
  "weaponsList": []
}
                </code>
             </pre>
        </td>
    </tr>



    <tr>
        <td>GET api/Characters/{id} </td>
        <td>Return Character with id </td>
        <td> N/A </td>
        <td>
            <pre>
                <code>
{
    "statusCode": 200,
    "statusDescription": "OK",
    "charactersList": [
        {
            "characterId": 1,
            "characterName": "SKY",
            "creationDate": "2022-04-29T00:00:00",
            "weapon1Id": 1,
            "weapon2Id": 1,
            "weapon3Id": 1
        }
    ],
    "weaponsList": []
}
                </code>
             </pre>
        </td>
    </tr>



</table>
