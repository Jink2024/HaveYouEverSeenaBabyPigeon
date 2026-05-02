using UnityEngine;

public static class SpriteTools
{
    public static Vector3 ConstrainToScreenSimple(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        if (screenPosition.x > Screen.width)
            screenPosition.x = Screen.width;

        if (screenPosition.x < 0)
            screenPosition.x = 0;

        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        if (screenPosition.y < 0)
            screenPosition.y = 0;

        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
    
    public static Vector3 ConstrainToScreen(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        float halfWidth = SpriteHalfWidth(spriteRenderer);
        float halfHeight = SpriteHalfHeight(spriteRenderer);

        if (screenPosition.x + halfWidth > Screen.width)
            screenPosition.x = Screen.width - halfWidth;

        if (screenPosition.x - halfWidth < 0)
            screenPosition.x = halfWidth;

        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    // Problem related to world/screen coordinates, that's why player is stopped before the end of screen
    // But maybe it's better this way.
    private static float SpriteHalfWidth(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.width / 2;
    }

    private static float SpriteHalfHeight(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.height / 2;
    }
}