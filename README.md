# Inl-mningsuppgift-6-Bygg-din-egen-id-med-React

## API

För att få igång API öppna det i VS och vid behov ändra connection string som nu är satt till PostgreSQL. 
Kör en update-database i package manager console för att få en databas.

### API spec
Jag har byggt min egna Autentisering för att slippa Identity Core. Jag har använt JWT.

## Frontend

För att få igång frontend kör en npm i, och därefter en npm run dev och starta localhost.

### Frontend Spec
Jag har byggt frontenden i React med NextJS och TypeScript.

## Inloggning

Det finns ett privat konto och ett företagskonto färdigt för användning. 
Du loggar in med private@test.com alternativt company@test.com med lösenord Admin123!

Du blir redirected till olika startsidor beroende på kontotyp, en privatperson ser jobbannonser och ett företag ser privatpersoner.

# JobSwipe
JobSwipe är en modern jobbsökningsplattform i Tinder-stuk där privatpersoner swipar på jobbannonser och företag swipar på jobbsökande.
Matchar man låses chatten upp och man kan boka in en intervju.

# Reflektion
Har försökt hålla mig till server side rendering på pages men de flesta komponenter är klient renderade eftersom de är dynamiska och använder sig av hooks.
Jag har lagt ner en hel del jobb på APIet för att få autentiseringen att fungera med JWT vilket var väldigt intressant, och när man håller sig borta från Identity förstår man sig på vad som händer vilket är nyttigt. 

Om jag hade gjort om det från början hade jag valt Vue 3 istället då det nya Dev Tools är riktigt bra där och underlättar enormt samt att jag föredrar deras syntax.
