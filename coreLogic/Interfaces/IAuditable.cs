using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLogic.Interfaces;

public interface IAuditable
{
	DateTime DateCreated { get; set; }

	int CreatorId { get; set; }

	string CreatorName { get; set; }

	DateTime DateModified { get; set; }

	int ModifierId { get; set; }

	string ModifierName { get; set; }
}