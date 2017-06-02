using UnityEngine;
using System.Collections;


namespace DemolitionStudios.DemolitionMedia
{
    [AddComponentMenu("Demolition Media/Render to mesh material")]
    public class RenderToMeshMaterial : MonoBehaviour
    {
        /// Source media component with video to map
        public Media SourceMedia;
        /// Target mesh renderer instance
		public MeshRenderer TargetMesh;
        /// Fallback texture
        public Texture FallbackTexture;
        /// Scale factor
        public Vector2 Scale = Vector2.one;
        /// Offset vecotr
        public Vector2 Offset = Vector2.zero;

        void Update()
        {
			if (SourceMedia == null || SourceMedia.VideoRenderTexture == null)
            {
                Apply(FallbackTexture, false, false);
                return;
            }

            Apply(SourceMedia.VideoRenderTexture, SourceMedia.VideoNeedFlipX, SourceMedia.VideoNeedFlipY);
        }

        private void Apply(Texture texture, bool flipX, bool flipY)
        {
			if (TargetMesh == null)
            {
                return;
            }

            Vector2 scale = Scale;
            Vector2 offset = Offset;
            if (!flipX)
            {
                scale.Scale(new Vector2(-1.0f, 1.0f));
                offset.x += 1.0f;
            }
            if (flipY)
            {
                scale.Scale(new Vector2(1.0f, -1.0f));
                offset.y += 1.0f;
            }

			Material[] materials = TargetMesh.materials;
			if (materials != null)
			{
				for (int i = 0; i < materials.Length; i++)
				{
					Material mat = materials[i];
					if (mat != null)
					{
						mat.mainTexture = texture; 

						if (texture != null)
						{
							mat.mainTextureScale = scale;
							mat.mainTextureOffset = offset;
						}
					}
				}
			}
		}

        void OnEnable()
        {
			if (TargetMesh == null)
			{
				TargetMesh = this.GetComponent<MeshRenderer>();
				if (TargetMesh == null)
				{
					Debug.LogWarning("[DemolitionMedia] RenderToMeshMaterial: no MeshRenderer component set or found in " + this.name);
				}
			}

            Update();
        }

        void OnDisable()
        {
            Apply(FallbackTexture, false, false);
        }
    }
}