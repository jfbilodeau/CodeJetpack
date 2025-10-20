using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeJetpack.Business
{
    /// <summary>
    /// Manager that maintains a collection of <see cref="JfJetpack"/> instances.
    /// Provides Add, Remove and Sort functionality and is enumerable.
    /// </summary>
    public class JfJetpackManager : IEnumerable<JfJetpack>
    {
        private readonly List<JfJetpack> _jetpacks = new();

        /// <summary>
        /// Factory interface for creating <see cref="JfJetpack"/> instances.
        /// Implementations can provide different creation strategies.
        /// </summary>
        public interface IJfJetpackFactory
        {
            JfJetpack Create(string name, int startingFuel = 100, float startingAltitude = 0f);
        }

        private class DefaultJetpackFactory : IJfJetpackFactory
        {
            public JfJetpack Create(string name, int startingFuel = 100, float startingAltitude = 0f)
                => new JfJetpack(name, startingFuel, startingAltitude);
        }

        private readonly IJfJetpackFactory _factory;

        /// <summary>
        /// Number of jetpacks in the manager.
        /// </summary>
        public int Count => _jetpacks.Count;

        /// <summary>
        /// Construct a manager with an optional factory. When no factory is provided,
        /// a default factory that calls the <see cref="JfJetpack"/> constructor is used.
        /// </summary>
        public JfJetpackManager(IJfJetpackFactory? factory = null)
        {
            _factory = factory ?? new DefaultJetpackFactory();
        }

        /// <summary>
        /// Add a jetpack to the manager.
        /// </summary>
        public void Add(JfJetpack jetpack)
        {
            if (jetpack is null) throw new ArgumentNullException(nameof(jetpack));
            _jetpacks.Add(jetpack);
        }

        /// <summary>
        /// Factory method: create a new <see cref="JfJetpack"/>, add it to the manager,
        /// and return the instance.
        /// </summary>
        public JfJetpack Create(string name, int startingFuel = 100, float startingAltitude = 0f)
        {
            var jp = _factory.Create(name, startingFuel, startingAltitude);
            Add(jp);
            return jp;
        }

        /// <summary>
        /// Remove a jetpack from the manager. Returns true when removed.
        /// </summary>
        public bool Remove(JfJetpack jetpack)
        {
            if (jetpack is null) throw new ArgumentNullException(nameof(jetpack));
            return _jetpacks.Remove(jetpack);
        }

        /// <summary>
        /// Convenience: sort jetpacks by name (ascending or descending).
        /// </summary>
        public void SortByName(bool ascending = true) =>
            _jetpacks.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal) * (ascending ? 1 : -1));

        /// <summary>
        /// Return a read-only snapshot of the current jetpacks.
        /// </summary>
        public ReadOnlyCollection<JfJetpack> AsReadOnly() => _jetpacks.AsReadOnly();

        /// <summary>
        /// Enumerate the jetpacks.
        /// </summary>
        public IEnumerator<JfJetpack> GetEnumerator() => _jetpacks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
