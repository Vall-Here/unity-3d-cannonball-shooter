using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallGenerator : MonoBehaviour
{
    [Header("Prefab dan Parent")]
    public GameObject brickPrefab;         // Prefab batu bata
    public Transform wallParent;           // Parent object (Wall)

    [Header("Ukuran Tembok")]
    public int width = 10;                 // Lebar tembok
    public int height = 5;                 // Tinggi tembok
    public float brickSpacing = 0.1f;      // Jarak antar batu bata

    [Header("Variasi Batu Bata")]
    public GameObject[] brickVariants;     // Array untuk variasi prefab batu bata

    void Start()
    {
        if (wallParent == null)
        {
            wallParent = this.transform;    // Jika wallParent tidak di-set, gunakan transform objek ini
        }
        GenerateWall();
    }

    void GenerateWall()
    {
        // Mulai dari posisi dasar tembok
        Vector3 nextPos = Vector3.zero;

        // Loop untuk membuat tembok dengan menghitung posisi batu bata satu per satu
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Pilih prefab batu bata secara acak jika ada variasi
                GameObject brickToInstantiate = brickPrefab;
                if (brickVariants.Length > 0)
                {
                    brickToInstantiate = brickVariants[Random.Range(0, brickVariants.Length)];
                }

                // Hitung posisi relatif terhadap parent Wall
                Vector3 brickPosition = new Vector3(
                    nextPos.x + (x * (1 + brickSpacing)) + Random.Range(0f, 0.2f),  // Posisi horizontal
                    nextPos.y + (y * 1 + Random.Range(0f, 0.2f)),  // Posisi vertikal
                    nextPos.z                               // Posisi depan
                );

                // Instantiate batu bata pada posisi yang dihitung
                GameObject brick = Instantiate(brickToInstantiate, brickPosition, Quaternion.identity);
                brick.transform.parent = wallParent; // Set parent untuk brick

                // Nama batu bata bisa disesuaikan
                brick.name = $"Brick_{x}_{y}";

                // Optional: Mengatur rotasi batu bata (jika diperlukan)
                brick.transform.rotation = Quaternion.identity;

                // Jika kamu ingin menambahkan efek atau properti lainnya, bisa ditambahkan di sini
            }
        }
    }
}
