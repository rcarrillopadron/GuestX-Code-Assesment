# GuestX Code Assesment

## Q1. Transmit sensitive information

You will not need to write code here, only provide pseudo-code, or written solutions.

Our company needs to send out time sensitive and highly personal information to clientele. Information cannot be a savable format at any time. So no emails, faxes, texts, or anything that would leave a paper trail.

- How would you solve this problem and what technologies would you use?
- What questions would you ask to further your solution or find a better solution?

### Answer

> The answer depends on the amount of data transmitted. My first thoght would be to use a set of streams like the `MemoryStream` and `CryptoStream` to encrypt the data during transmition and using a Public/Private key via Tcp. Yes, there are other things to consider like the availability of the network in case it fails, but this is not the point yet. Asymetric encryption would be my first choice for this problem.
>
> Some questions I would make to accomplish this task properly are:
>
> 1. How the information will be used?
> 2. Can we use a VPN? What level of encryption or security is needed?
> 3. Do we need any kind of validation or ordering?
> 4. Is this a one time transmition?
> 5. Do our customers have an EndPoint (like an API endpoint) that can be used to pass the information via HTTPS/TSL?
> 6. What is the reasoning behind not leaving a paper trail? The questions says "no email", do they print their emails? Can we use another kind of tecnology like HTTPS/TLS or encryption at the network level?
> 7. What kind of budget do we have (Money and time)?

### Pseudocode

``` csharp
var clients = new List<Client> {
   "client1-srv",
   "client2-srv",
}

foreach(var client in clients)
{
    var tcp = new TcpClient(client);

    using(var netStream = tcp.Getstream())
    {
        var crypto = new RijndaelManaged();
        byte[] key = {....};// Bytes
        byte[] vector = {....};

        using(var cs = new CryptoStream(netStream))
        {
            crypto.CreateEncryptor(key, vector);

            var dataToPass = //Read the data from somewhere
            using (var sw = new StreamWriter(cs))
                sw.Write(dataToPass);
        }
    }
}
```
