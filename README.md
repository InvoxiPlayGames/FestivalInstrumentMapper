# FestivalInstrumentMapper

Maps a variety of Guitar Hero and Rock Band instruments as Xbox One guitars, for usage in Fortnite Festival's new plastic/"pro" modes.

In theory, it supports Santroller, Xbox 360, PS3, Wii Rock Band, and Raphnet guitars and adapters.

**Currently in beta, please expect bugs!**

**This is an unofficial third-party tool, provided with NO WARRANTY OR GUARANTEE. This utility is not associated with or endorsed by Epic Games, Inc.**

## Looking for downloads? [See Releases](https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/releases/latest)

## Instructions:

Currently, only the latest versions of Windows 10 (10.0.19045.0) and Windows 11 (10.0.22631.0) are supported.

1. [Download FestivalInstrumentMapper](https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/releases/latest)
2. Extract the ZIP file somewhere memorable on your computer.
3. Enable Windows Developer Mode.
    * On **Windows 11**: Settings -> System -> For developers -> Developer Mode
    * On **Windows 10**: Settings -> Update & Security -> For developers -> Developer Mode
4. Launch FestivalInstrumentMapper.exe.
5. Select your guitar from the drop down selection.
6. Hit "Start Mapping", and Fortnite should now see a guitar controller and let you play Plastic Lead and Plastic Bass.

*For Xbox 360 guitars, please see info in the "Set up Xbox 360 Controller Hiding" page of FestivalInstrumentMapper.*

## Known Issues:

* Whammy and tilt, for overdrive activations, can be tempremental.
* Sometimes the app won't fully close and will be stuck in the background.
* Xbox 360 controllers can cause framerate issues.
* Versions of Windows with random services removed ("debloated") won't work. This can not be fixed.

Please report any other issues you run into on the [issue tracker](https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/issues).
When reporting issues, please read the [FAQ](https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/wiki/FAQ-and-About) and check
for any existing issues before submitting a new report.

## Credits

* [TheNathannator](https://github.com/TheNathannator) for helping get this project off the ground and documenting every guitar under the sun.
* [sanjay900](https://github.com/sanjay900) for documentation help, testing and the amazing Santroller Guitar firmware.
* [Nefarius](https://github.com/Nefarius) for the HidHide utility and DeviceManagement library.
* xX760Xx, Acai, JasonParadise and aWiseMoose from Lore Hero for helping test a bunch of different guitars, and being cool.

## Building

**This is only for advanced users and developers who want to work on the tool! If you just want to use it,
download the latest release from the releases page.**

To compile this yourself, you need Visual Studio 2022 with the C++ and C# development tools installed, as well
as the .NET 8 SDK.

Compiling the main mapper utility can be done by opening the .sln and building it normally.

For the compiled ou'll need to compile the following 2 DLLs and put them next to the resulting EXE file:

* [PlasticBandToGip](https://github.com/InvoxiPlayGames/PlasticBandToGip) - native components for translating controllers
* [GipSyntheticEx](https://github.com/InvoxiPlayGames/GipSyntheticEx) - extensions to the Xbox GIP Synthetic library.

## License

FestivalInstrumentMapper is Free Software, licensed to you under version 2 of the GNU General Public License.
Read the LICENSE.txt file for more information.

FestivalInstrumentMapper uses the following third-party libraries:

* Nefarius.Drivers.HidHide, licensed under the MIT License.
* Nefarius.Utilities.DeviceManagement, licensed under the MIT License.
