﻿namespace Wpm.SharedKernel;

public abstract class Entity : IEquatable<Entity>
{
    /* int is generally avoided in DDD */
    public Guid Id { get; init; }

    public bool Equals(Entity? other)
    {
        return other?.Id == Id;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return left?.Id == right?.Id;
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return left?.Id != right?.Id;
    }
}
