# LIBRARY_NAME
YOUR_DESCRIPTION

## Usage
You can build the library locally with:

```
dotnet pack ./Source/LIBRARY_NAME.csproj -c Release -p:Version=1.0.0 -o ./Artifacts
```

To install it into a local game project (Replace the path after -s to your local path.):

```
dotnet add package LIBRARY_NAME -s "C:\ThePathToYourLibraryBuilds\"
```

## Publish

1. To publish your library to NuGet.
   1. Generate a new API key from <https://www.nuget.org/account/apikeys>.
   2. Allow the key to `Push` and `Push new packages and package versions`.
   3. Copy the key.
2. Go to your GitHub repo for your library.
   1. Go in the `Settings`.
   2. In the Security section, go in `Secrets and variables`.
   3. Select `Actions`.
   4. In the repository secrets, create a new repository secret.
   5. Name it `NUGETAPIKEY`.
   6. Paste the NuGet API key from earlier.
   7. Click `Add secret`.
3. To publish the library to NuGet, create a new version tag with git:
   1. `git tag v0.0.1`
   2. `git push --tags`
   3. This will launch a pipeline on GitHub that will automatically build your package and release it on NuGet.
4. To release new versions of the library, repeat step 3.
