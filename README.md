# audio-system-example-unity
 
## Summary
### Audio system
This is an example of what can be built on top of Unity's audiosources.

Features:
- Sound-centered assets management system based on scriptable objects 
- Three types of sound containers - single sound, random collection and parameter-based collection
- Dynamic snapshot-based priority system (i.e., some sounds can be more important and loader than others)

### Sample scene
The sample scene contains a simple level with two boxes (wooden and metal), two types of npcs (enemy and ally), and bullet impact sound logic.

- Player's and ally's impact sounds have the highest and the lowest priority accordingly
- Sound sample changes based on a box's surface type
