#import <Foundation/Foundation.h>
#import "VDMEntry.h"

@interface VDMEntryCell : UITableViewCell {
	IBOutlet UITextView *textView;
	
}

@property (nonatomic, readonly) UITextView *textView;
@property (weak, nonatomic) IBOutlet UILabel *authors;
@property (weak, nonatomic) IBOutlet UILabel *dates;

@end
