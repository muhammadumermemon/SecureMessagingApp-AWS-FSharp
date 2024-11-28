fsharp
open Amazon.CognitoIdentityProvider
open Amazon.CognitoIdentityProvider.Model
open Amazon.SimpleNotificationService
open Amazon.SimpleNotificationService.Model
open Amazon.KeyManagementService
open Amazon.KeyManagementService.Model

// User Authentication (Amazon Cognito User Pools)
let userPoolId = "YOUR_USER_POOL_ID"
let clientId = "YOUR_CLIENT_ID"

let userPool = new CognitoUserPool(userPoolId, clientId)

let user = new CognitoUser("username", userPool)

user.SessionValidityTimeout <- TimeSpan.FromHours(1.0)

user.StartWithSrpAuthAsync("password")
|> Async.RunSynchronously

// Message Routing (Amazon SNS)
let sns = new AmazonSimpleNotificationServiceClient("YOUR_ACCESS_KEY", "YOUR_SECRET_KEY", "YOUR_REGION")

let topicArn = "YOUR_TOPIC_ARN"
let message = "Hello, world!"

sns.PublishAsync(new PublishRequest(topicArn, message))
|> Async.RunSynchronously

// Encryption (AWS KMS)
let kms = new AmazonKeyManagementServiceClient("YOUR_ACCESS_KEY", "YOUR_SECRET_KEY", "YOUR_REGION")

let keyId = "YOUR_KEY_ID"
let plaintext = "Hello, world!"

kms.EncryptAsync(new EncryptRequest(keyId, plaintext))
|> Async.RunSynchronously
