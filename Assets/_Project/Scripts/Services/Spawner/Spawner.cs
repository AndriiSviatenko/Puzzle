using _Project.Scripts.Puzzles;
using _Project.Scripts.Services.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services.Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private PuzzleElement start;
        [SerializeField] private PuzzleElement straight;
        [SerializeField] private PuzzleElement tShape;
        [SerializeField] private PuzzleElement lShape;
        [SerializeField] private PuzzleElement doubleLShape;
        [SerializeField] private PuzzleElement end;

        private ClickDetection.ClickDetection _clickService;
        private PuzzleGrid _grid;
        private PuzzleElement _start;
        public PuzzleElement StartElement => _start;

        private List<PuzzleElement> _ends = new();
        public List<PuzzleElement> EndElements => _ends;

        private List<PuzzleElement> path = new();
        private List<PuzzleElement> _puzzles = new();

        private PathValidator.PathValidator _pathValidator;

        [Inject]
        private void Construct(PathValidator.PathValidator pathValidator, PuzzleGrid grid, ClickDetection.ClickDetection clickService)
        {
            _pathValidator = pathValidator;
            _grid = grid;
            _clickService = clickService;
        }

        public IEnumerator StartSpawn()
        {
            yield return GenerateLevel();
            _grid.ArrangeGrid();
            _clickService.OnClickEvent += OnChange;
            yield return null;
        }

        private IEnumerator GenerateLevel()
        {
            var instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);
            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(end, Vector3.zero, Quaternion.identity, _grid.transform);
            _ends.Add(instance);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(end, Vector3.zero, Quaternion.identity, _grid.transform);
            _ends.Add(instance);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(doubleLShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(doubleLShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(doubleLShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(doubleLShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(end, Vector3.zero, Quaternion.identity, _grid.transform);
            _ends.Add(instance);
            instance.SetColor(Color.blue);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(start, Vector3.zero, Quaternion.identity, _grid.transform);
            _start = instance;
            _start.isConnected = true;
            _puzzles.Add(instance);

            instance = Instantiate(doubleLShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(tShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(straight, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);

            instance = Instantiate(lShape, Vector3.zero, Quaternion.identity, _grid.transform);
            _puzzles.Add(instance);
            yield return null;
        }

        public IEnumerator ClearPuzzle()
        {
            path.Clear();

            foreach (var puzzle in _puzzles)
                Destroy(puzzle.gameObject);

            _ends.Clear();
            _puzzles.Clear();
            yield return null;
        }


        private void OnChange(PuzzleElement puzzle) => 
            _pathValidator.UpdatePath(path, puzzle);
    }
}
