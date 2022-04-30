# Project Documentation

### Notes 
1. This API uses standard HTTP Requests with JSON 
request and response bodies.

2. In the table of endpoints, key value pairs in the 
REQUEST BODY that are marked with //Optional can be 
omitted from the body if desired.

3. In the table of endpoints, N/A for Request Body 
signifies that a request body is not required nor 
intended for that specific request.

4. WeaponIds in the Character DB are foreign keys 
referring to Weapons in the Weapons DB. If you attempt
to DELETE a Weapon that is part of ANY Character, you 
will see a 500 stack error. You must remove the Weapon 
Id from the Character(s) having them via PUTs.

5. Any Character can be deleted at any time as nothing 
in the Weapons DB has a foreign key referencing anything 
in the Characters DB.

6. The POST and PUT (without an Id) are meant to perform
the same way. For clarification, use POST and PUT 
(without an Id) only to insert new items and use PUT 
(with an Id) only to update items.

<br>

### Endpoints

<body>
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
            <td>Return Character with id in DB</td>
            <td>N/A </td>
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
        <tr>
            <td>POST api/Characters </td>
            <td>Insert new Character into DB </td>
            <td>
                <pre>
                    <code>
{
    "CharacterId": 3,
    "CharacterName": "JAY4123",
    "CreationDate" : "22-04-2022", //Optional
    "Weapon1Id": 1,                //Optional
    "Weapon2Id": 2,                //Optional
    "Weapon3Id": 1                 //Optional   
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
IF SUCCESS
{
    "statusCode": 201,
    "statusDescription": "Created",
    "charactersList": [],
    "weaponsList": []
}
<br>
IF FAIL (Character Already Exists in DB)
{
    "statusCode": 409,
    "statusDescription": "Conflict",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>PUT api/Characters </td>
            <td>Insert new Character into DB </td>
            <td>
                <pre>
                    <code>
{
    "CharacterId": 3,
    "CharacterName": "JAY4123",
    "CreationDate" : "22-04-2022", //Optional
    "Weapon1Id": 1,                //Optional
    "Weapon2Id": 2,                //Optional
    "Weapon3Id": 1                 //Optional   
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
IF SUCCESS
{
    "statusCode": 201,
    "statusDescription": "Created",
    "charactersList": [],
    "weaponsList": []
}
<br>
IF FAIL (Character Already Exists in DB)
{
    "statusCode": 409,
    "statusDescription": "Conflict",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>PUT api/Characters/{id} </td>
            <td>Update Character with id already in DB </td>
            <td>
                <pre>
                    <code>
{
    "CharacterId": 3,
    "CharacterName": "JAY4123",
    "CreationDate" : "22-04-2022", //Optional
    "Weapon1Id": 1,                //Optional
    "Weapon2Id": 2,                //Optional
    "Weapon3Id": 1                 //Optional   
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
Successful Update
{
    "statusCode": 201,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
<br>
Failed Update (ex. Character does not exist)
{
    "statusCode": 404,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>DELETE api/Characters/{id} </td>
            <td>Delete Character with id already in DB </td>
            <td>
                N/A
            </td>
            <td>
                <pre>
                    <code>
Successful
{
    "statusCode": 204,
    "statusDescription": "No Content",
    "charactersList": [],
    "weaponsList": []
}
<br>
Failed (Character with id does not exist in DB)
{
    "statusCode": 404,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>GET api/Weapons </td>
            <td>Return all Weapons in DB </td>
            <td>N/A</td>
            <td>
                <pre>
                    <code>
{
    "statusCode": 200,
    "statusDescription": "OK",
    "charactersList": [],
    "weaponsList": [
        {
            "weaponId": 1,
            "weaponName": "Duty Bound",
            "class": "Auto Rifle",
            "impact": 1,
            "range": 2,
            "stability": 3,
            "handling": 4,
            "reloadSpeed": 5
        },
        {
            "weaponId": 2,
            "weaponName": "Origin Story",
            "class": "Auto Rifle",
            "impact": 10,
            "range": 9,
            "stability": 8,
            "handling": 7,
            "reloadSpeed": 6
        }
    ]
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>GET api/Weapons/{id} </td>
            <td>Return Weapon in DB with id </td>
            <td>N/A</td>
            <td>
                <pre>
                    <code>
{
    "statusCode": 200,
    "statusDescription": "OK",
    "charactersList": [],
    "weaponsList": [
        {
            "weaponId": 1,
            "weaponName": "Duty Bound",
            "class": "Auto Rifle",
            "impact": 1,
            "range": 2,
            "stability": 3,
            "handling": 4,
            "reloadSpeed": 5
        }
    ]
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>POST api/Weapons </td>
            <td>Insert new Weapon into DB </td>
            <td>
                <pre>
                    <code>
{
    "WeaponId": 1,
    "WeaponName": "Duty Bound",
    "Class": "Auto Rifle",
    "Impact": 1,
    "Range": 2,
    "Stability": 3,
    "Handling": 4,
    "ReloadSpeed": 5
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
IF SUCCESS
{
    "statusCode": 201,
    "statusDescription": "Created",
    "charactersList": [],
    "weaponsList": []
}
<br>
IF FAIL (Weapon Already Exists in DB)
{
    "statusCode": 409,
    "statusDescription": "Conflict",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>PUT api/Weapons </td>
            <td>Insert new Weapon into DB </td>
            <td>
                <pre>
                    <code>
{
    "WeaponId": 1,
    "WeaponName": "Duty Bound",
    "Class": "Auto Rifle",
    "Impact": 1,
    "Range": 2,
    "Stability": 3,
    "Handling": 4,
    "ReloadSpeed": 5
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
IF SUCCESS
{
    "statusCode": 201,
    "statusDescription": "Created",
    "charactersList": [],
    "weaponsList": []
}
    <br>
IF FAIL (Weapon Already Exists in DB)
{
    "statusCode": 409,
    "statusDescription": "Conflict",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>PUT api/Weapons/{id} </td>
            <td>Update Weapon with id already in DB </td>
            <td>
                <pre>
                    <code>
{
    "WeaponId": 1,
    "WeaponName": "Duty Bound",
    "Class": "Auto Rifle",
    "Impact": 1,
    "Range": 2,
    "Stability": 3,
    "Handling": 4,
    "ReloadSpeed": 5
}
                    </code>
                </pre>
            </td>
            <td>
                <pre>
                    <code>
Successful Update
{
    "statusCode": 201,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
    <br>
Failed Update (Weapon does not exist in DB)
{
    "statusCode": 404,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
        <tr>
            <td>DELETE api/Weapon/{id} </td>
            <td>Delete Weapon with id already in DB </td>
            <td>
                N/A
            </td>
            <td>
                <pre>
                    <code>
Successful
{
    "statusCode": 204,
    "statusDescription": "No Content",
    "charactersList": [],
    "weaponsList": []
}
<br>
Failed (Weapon with id does not exist in DB)
{
    "statusCode": 404,
    "statusDescription": "Not Found",
    "charactersList": [],
    "weaponsList": []
}
                    </code>
                </pre>
            </td>
        </tr>
    </table>
</body>
